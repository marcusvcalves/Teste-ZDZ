<script setup>
import { defineProps, defineEmits } from 'vue';
import { useMainStore } from '@/store/index';

const store = useMainStore();

const emit = defineEmits(['edit']);

const props = defineProps({
  product: {
    type: Object,
    required: true
  }
});

const deleteProduct = (productId) => {
  store.deleteProduct(productId)
    .then(() => {
      store.fetchProducts();
    })
    .catch(error => {
      console.log(error);
    });
};

const editProduct = () => {
  emit('edit', props.product);
};
</script>

<template>
  <v-col cols="auto">
    <v-btn color="primary" @click="editProduct">
      <v-icon>mdi-pencil</v-icon>
    </v-btn>
  </v-col>

  <v-col cols="auto">
    <v-btn color="red" @click="deleteProduct(product.id)">
      <v-icon>mdi-delete</v-icon>
    </v-btn>
  </v-col>
</template>