<template>
  <v-app>
    <SearchBar />
    <v-main>
      <v-container class="mt-4">
        <v-row class="ml-4 mb-4" cols="12" sm="6" md="4">
          <CreateButtons />
        </v-row>
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
        <Pagination 
          :currentPage="currentPage" 
          :totalPages="totalPages"
          @page-change="changePage" 
        />
      </v-container>
    </v-main>
  </v-app>
</template>

<script setup>
import { useMainStore } from '@/store/index';
import { computed, onMounted } from 'vue';

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