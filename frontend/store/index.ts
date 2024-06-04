import { defineStore } from "pinia";
import axios from "axios";

export const useMainStore = defineStore("main", {
  state: () => ({
    products: [],
    categories: [],
    pageIndex: 1,
    totalPages: 0,
  }),
  getters: {
    getProducts(state) {
      return state.products;
    },
    getCategories(state) {
      return state.categories;
    },
  },
  actions: {
    async fetchProducts(pageIndex = 1, pageSize = 6) {
      try {
        const response = await axios.get(`http://localhost:8080/api/products?pageIndex=${pageIndex}&pageSize=${pageSize}`);
        const data = response.data;
        this.products = data.items;
        this.pageIndex = data.pageIndex;
        this.totalPages = data.totalPages;
      } catch (error) {
        console.log(error);
      }
    },
    changePage(newPage: number) {
      this.fetchProducts(newPage);
    },
  },
});
