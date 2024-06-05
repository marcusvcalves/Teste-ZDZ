<script setup>
import { computed } from 'vue';
import { defineProps, defineEmits } from 'vue';

const props = defineProps({
  currentPage: {
    type: Number,
    required: true,
  },
  totalPages: {
    type: Number,
    required: true,
  },
});

const emit = defineEmits(['page-change']);

const visiblePages = computed(() => {
  const startPage = Math.max(1, props.currentPage - 1); 
  const endPage = Math.min(props.totalPages, props.currentPage + 1);
  return Array.from({ length: endPage - startPage + 1 }, (_, index) => startPage + index);
});

const setCurrentPage = (newPage) => {
  if (newPage >= 1 && newPage <= props.totalPages) {
    emit('page-change', newPage);
  }
};
</script>

<template>
  <div v-if="totalPages > 1" class="pagination">
    <v-btn variant="flat" color="primary" @click="setCurrentPage(1)" :disabled="currentPage === 1">
      Primeira
    </v-btn>
    <v-btn variant="flat" color="primary" @click="setCurrentPage(currentPage - 1)" :disabled="currentPage === 1">
      Anterior
    </v-btn>

    <v-btn
      v-for="pageNumber in visiblePages"
      :key="pageNumber"
      @click="setCurrentPage(pageNumber)"
      :class="{ active: pageNumber === currentPage }"
      variant="flat"
      color="primary"
    >
      {{ pageNumber }}
    </v-btn>

    <v-btn variant="flat" color="primary" @click="setCurrentPage(currentPage + 1)" :disabled="currentPage === totalPages">
      Próxima
    </v-btn>
    <v-btn variant="flat" color="primary" @click="setCurrentPage(totalPages)" :disabled="currentPage === totalPages">
      Última
    </v-btn>
  </div>
</template>

<style scoped>
.pagination {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 8px;
  margin: 48px auto;
}

.pagination .v-btn {
  border-radius: 4px;
  padding: 8px 16px;
  font-size: 1rem; 
  cursor: pointer;
  transition: background-color 0.3s, color 0.3s, box-shadow 0.3s;
}

.pagination .v-btn:disabled {
  opacity: 0.5;
  cursor: not-allowed;
}

.pagination .v-btn:hover:not(:disabled) {
  box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.1);
}

.pagination .v-btn.active {
  font-weight: bold;
}
</style>
