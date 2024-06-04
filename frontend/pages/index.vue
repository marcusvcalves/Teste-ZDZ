<template>
  <v-app>
    <SearchBar />
    <v-main class="mt-12">
      <v-row>
        <v-col
          v-for="product in products" 
          :key="product.id" 
          cols="12"
          sm="6"
          md="4"
        >
          <Card :product="product" />
        </v-col>
      </v-row>
    </v-main>
  </v-app>
</template>

<script setup>
import { useMainStore } from '@/store/index';
import SearchBar from '@/components/SearchBar.vue';
import Card from '@/components/Card.vue';

const store = useMainStore();
const products = store.products;
</script>