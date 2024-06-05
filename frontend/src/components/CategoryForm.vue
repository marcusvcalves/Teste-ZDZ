<script setup>
import { ref, defineProps, defineEmits, watch } from 'vue';
import { useMainStore } from '@/store/index';

const store = useMainStore();

const props = defineProps({
  show: Boolean
});

const emit = defineEmits(['update:show']);

const category = ref({
  name: ''
});

const updateShow = (value) => {
  emit('update:show', value);
};

const close = () => {
  emit('update:show', false);
};

const save = async () => {
  await store.createCategory(category.value);
  close();
};

const showDialog = ref(props.show);

watch(() => props.show, (newShowValue) => {
  showDialog.value = newShowValue;
});

</script>

<template>
  <v-dialog :model-value="show" @update:model-value="updateShow" max-width="500px">
    <v-card>
      <v-btn class="ml-auto" icon @click="close">
        <v-icon>mdi-close</v-icon>
      </v-btn>

      <v-card-text>
        <v-form>
          <v-text-field label="Nome da Categoria" v-model="category.name" required></v-text-field>
        </v-form>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="close">Cancelar</v-btn>
        <v-btn color="primary" @click="save">Salvar</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>