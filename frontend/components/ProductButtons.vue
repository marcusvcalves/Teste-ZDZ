<script setup>
import { defineProps, defineEmits } from 'vue';
import { useMainStore } from '@/store/index';

const store = useMainStore();

const emit = defineEmits(['edit']);

const props = defineProps({
  id: {
    type: String,
    required: true
  }});

const deleteProduct = (productId) =>{
  store.deleteProduct(productId)
    .then(() => {
      store.fetchProducts();
    })
    .catch(error => {
      console.error('Erro ao deletar o produto:', error);
    });
}
</script>

<template>
    <v-col cols="auto">
      <v-btn color="primary" @click="edit">
        <v-icon>mdi-pencil</v-icon>
      </v-btn>
    </v-col>

    <v-col cols="auto">
      <v-btn color="red" @click="deleteProduct(id)">
        <v-icon>mdi-delete</v-icon>
      </v-btn>
    </v-col>
</template>