<script setup>
import { ref, defineProps, defineEmits, watch } from 'vue';
import { useMainStore } from '@/store/index';
import { useEventBus } from '@vueuse/core';

const store = useMainStore();

const props = defineProps({
  show: Boolean,
  product: {
    type: Object,
    default: () => ({
      name: '',
      price: '',
      description: '',
      categoriesIds: []
    })
  }
});

const emit = defineEmits(['update:show']);

const showDialog = ref(props.show);

watch(() => props.show, (newShowValue) => {
  showDialog.value = newShowValue;
});

const product = ref({ ...props.product });

const selectedCategoriesIds = ref(product.value.categoriesIds);

const updateSelectedCategories = (selectedIds) => {
  selectedCategoriesIds.value = selectedIds;
  product.value.categoriesIds = selectedIds;
};

const updateShow = (value) => {
  emit('update:show', value);
};

const clearForm = () => {
  product.value = {
    name: '',
    price: '',
    description: '',
    categoriesIds: []
  };
  selectedCategoriesIds.value = [];
};

const close = () => {
  emit('update:show', false);
};

const save = async () => {
  try {
    if (props.product.id) {
      await store.updateProduct(props.product.id, product.value);
    } else {
      await store.createProduct(product.value);
    }
    await store.fetchProducts();
    close();
    clearForm();
  } catch (error) {
    console.log(error);
  }
};

const categories = ref([]);

watchEffect(async () => {
  categories.value = await store.fetchCategories();
});

const bus = useEventBus('category-created');

bus.on(async () => {
  categories.value = await store.fetchCategories();
});

watch(showDialog, (newShowValue) => {
  if (!newShowValue) {
    clearForm();
  }
});

watch(() => props.product, (newProduct) => {
  product.value = { ...newProduct };
  selectedCategoriesIds.value = newProduct.categoriesIds;
});
</script>

<template>
  <v-dialog :model-value="showDialog" @update:model-value="updateShow" max-width="500px">
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