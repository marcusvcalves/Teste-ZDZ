<script setup>
import { ref } from 'vue';
import { defineProps } from 'vue';
import ProductButtons from './ProductButtons.vue';
import ProductForm from './ProductForm.vue';

const props = defineProps({
  product: {
    type: Object,
    required: true,
  },
});

const showForm = ref(false);
const selectedProduct = ref({});

const openEditForm = (product) => {
  selectedProduct.value = { ...product };
  showForm.value = true;
}

function formatPrice(price) {
  return new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(price);
}
</script>

<template>
  <v-card class="mx-auto" max-width="400" min-height="300" elevation="2">
    <v-row class="d-flex align-start justify-space-between mt-1 mr-1">
      <v-card-title>{{ product.name }}</v-card-title>
      <v-spacer></v-spacer>
      <ProductButtons :product="product" @edit="openEditForm" />
    </v-row>

    <v-card-subtitle class="text-h6">{{ formatPrice(product.price) }}</v-card-subtitle>

    <v-card-text>{{ product.description }}</v-card-text>
    
    <v-card-text class="d-flex flex-wrap"> 
      <v-btn
        v-for="category in product.categories"
        :key="category.id"
        variant="flat"
        color="teal"
        size="small"
        class="category-btn mr-2 mt-2"
      >
        {{ category.name }}
      </v-btn>
    </v-card-text>

    <v-card-actions>
      <v-btn color="primary" variant="flat" class="ml-2 mb-6">
        +Adicionar ao Carrinho
      </v-btn>
    </v-card-actions>
    
  </v-card>

  <ProductForm :show="showForm" :product="selectedProduct" @update:show="showForm = $event" />
</template>