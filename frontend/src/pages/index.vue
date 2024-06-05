<script setup>
import { useMainStore } from '@/store/index';
import { computed, onMounted, ref, watch } from 'vue';
import SearchBar from '@/components/SearchBar.vue';
import CreateButtons from '@/components/CreateButtons.vue';
import Card from '@/components/Card.vue';
import Pagination from '@/components/Pagination.vue';

const store = useMainStore();
const searchQuery = ref('');

const products = computed(() => store.getProducts);
const currentPage = computed(() => store.pageIndex);
const totalPages = computed(() => store.totalPages);

onMounted(() => {
  store.fetchProducts(currentPage.value, 6, searchQuery.value);
});

const changePage = (newPage) => {
  store.changePage(newPage, searchQuery.value);
};

const handleSearch = (query) => {
  searchQuery.value = query;
  store.fetchProducts(1, 6, searchQuery.value);
};

watch(searchQuery, () => {
  store.fetchProducts(1, 6, searchQuery.value);
});

</script>

<template>
  <v-app>
    <SearchBar @search="handleSearch" v-model="searchQuery" />
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