<script setup>
import { ref, defineEmits, defineProps } from 'vue';

const emit = defineEmits(['search']);
const props = defineProps({
  modelValue: { type: String, default: "" },
});

const searchQuery = ref(props.modelValue);

const updateSearchQuery = () => {
  emit('update:modelValue', searchQuery.value);
  emit('search', searchQuery.value);
};
</script>

<template>
  <v-app-bar color="primary" height="80">
    <v-container>
      <v-text-field
        class="mx-auto"
        variant="solo"
        prepend-inner-icon="mdi-magnify"
        label="Buscar produto"
        hide-details
        single-line
        density="compact"
        style="max-width: 400px; border-radius: 25px; caret-color: black;"
        v-model="searchQuery" 
        @input="updateSearchQuery"
      ></v-text-field>
    </v-container>
  </v-app-bar>
</template>