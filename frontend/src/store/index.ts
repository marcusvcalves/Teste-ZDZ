import { defineStore } from "pinia";
import { useEventBus } from '@vueuse/core'; 
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
    async fetchProducts(pageIndex = 1, pageSize = 6, searchQuery="") {
      try {
        const response = await axios.get(`http://localhost:8080/api/products?pageIndex=${pageIndex}&pageSize=${pageSize}&search=${searchQuery}`);
        const data = response.data;
        this.products = data.items;
        this.pageIndex = data.pageIndex;
        this.totalPages = data.totalPages;
      } catch (error) {
        console.log(error);
      }
    },
    async createProduct(req: Object){
      try {
        await axios.post("http://localhost:8080/api/products", req);
      } catch (error) {
        console.log(error);
      }

    },
    async updateProduct(id: Number, req: Object){
      try {
        await axios.put(`http://localhost:8080/api/products/${id}`, req);
      } catch (error) {
        console.log(error);
      }
    },
    async deleteProduct(productId: String){
      try {
        await axios.delete(`http://localhost:8080/api/products/${productId}`);
      } catch (error) {
        console.log(error);
      }
    },
    async fetchCategories() {
      try {
        const response = await axios.get('http://localhost:8080/api/categories');
        return response.data;
      } catch (error) {
        console.log(error);
        return [];
      }
    },
    async createCategory(req: Object){
      try {
        await axios.post("http://localhost:8080/api/categories", req);
        useEventBus('category-created').emit();
      } catch (error) {
        console.log(error);
      }
    },
    changePage(newPage: number, searchQuery = "") {
      this.fetchProducts(newPage, 6, searchQuery);
    },
  },
});
