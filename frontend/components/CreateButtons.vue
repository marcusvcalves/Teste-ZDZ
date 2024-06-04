<template>
  <v-row>
    <v-col cols="auto">
      <v-btn color="primary" @click="showProductModal = true">
        +Novo Produto
      </v-btn>
    </v-col>
    <v-col cols="auto">
      <v-btn color="primary" @click="showCategoryModal = true">
        +Nova Categoria
      </v-btn>
    </v-col>

    <ProductForm v-model:show="showProductModal" />
    <CategoryForm v-model:show="showCategoryModal" />
  </v-row>
</template>

<script setup>
import { ref } from 'vue';
import ProductForm from './ProductForm.vue';
import CategoryForm from './CategoryForm.vue';

const showProductModal = ref(false);
const showCategoryModal = ref(false);
</script>