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
    <Pagination 
      :currentPage="currentPage" 
      :totalPages="totalPages"
      @page-change="changePage" 
    />
  </v-app>
</template>

<script setup>
import { useMainStore } from '@/store/index';
import { computed, onMounted } from 'vue';
import SearchBar from '@/components/SearchBar.vue';
import Card from '@/components/Card.vue';
import Pagination from '@/components/Pagination.vue';

const store = useMainStore();

const products = computed(() => store.getProducts);
const currentPage = computed(() => store.pageIndex);
const totalPages = computed(() => store.totalPages);

onMounted(() => {
  store.fetchProducts();
});

const changePage = (newPage) => {
  store.changePage(newPage);
};
</script>