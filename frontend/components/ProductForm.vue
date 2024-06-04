<template>
  <v-dialog :model-value="show" @update:model-value="updateShow" max-width="500px">
    <v-card>
      <v-btn class="ml-auto" icon @click="close">
        <v-icon>mdi-close</v-icon>
      </v-btn>

      <v-card-text>
        <v-form>
          <v-text-field label="Nome do Produto" v-model="product.name" required></v-text-field>
          <v-text-field label="Preço" v-model="product.price" required type="number"></v-text-field>
          <v-textarea label="Descrição" required v-model="product.description"></v-textarea>
          <v-select
            v-model="product.categoriesIds"
            :items="categories"
            label="Categorias"
            multiple
            chips
            small-chips
            outlined
            item-title="name"
            item-value="id"
            @update:model-value="updateSelectedCategories"
            required
          ></v-select>
        </v-form>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="close">Cancelar</v-btn>
        <v-btn color="primary" @click="save">Salvar</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script setup>
import { ref, defineProps, defineEmits, watch, watchEffect } from 'vue';
import { useMainStore } from '@/store/index';
import axios from "axios";

const store = useMainStore();

const fetchCategories = async () => {
  try {
    const response = await axios.get('http://localhost:8080/api/categories');
    return response.data;
  } catch (error) {
    console.log(error);
    return [];
  }
};

const props = defineProps({
  show: Boolean
});

const emit = defineEmits(['update:show']);

const product = ref({
  name: '',
  price: '',
  description: '',
  categoriesIds: []
});

const selectedCategoriesIds = ref([]);

const updateSelectedCategories = (selectedIds) => {
  selectedCategoriesIds.value = selectedIds;
};

const updateShow = (value) => {
  emit('update:show', value);
};

const clearForm = () => {
  product.value.name = '';
  product.value.price = '';
  product.value.description = '';
  selectedCategoriesIds.value = [];
};

const close = () => {
  emit('update:show', false);
};

const save = async () => {
  try {
    await store.createProduct(product.value);
    await store.fetchProducts();
    close();
    clearForm();
  } catch (error) {
    console.log(error);
  }
};

const categories = ref([]);

watchEffect(async () => {
  categories.value = await fetchCategories();
});

watch(props, (newProps) => {
  if (!newProps.show) {
    clearForm();
  }
});
</script>
