<script setup>
import { onMounted, ref } from 'vue'
import { getOrders } from '../services/orderService'
import OrderTable from '../components/OrderTable.vue'

const orders = ref([])
const loading = ref(true)
const error = ref('')

async function loadOrders() {
  try {
    loading.value = true
    error.value = ''
    orders.value = await getOrders()
  } catch (err) {
    error.value = 'Kunne ikke hente ordrer fra API\'et.'
    console.error(err)
  } finally {
    loading.value = false
  }
}

onMounted(loadOrders)
</script>

<template>
  <section>
    <h2>Ordrer</h2>
    <p>Data hentes fra ASP.NET Core Web API.</p>

    <p v-if="loading">Henter ordrer...</p>
    <p v-else-if="error" class="error">{{ error }}</p>
    <OrderTable v-else :orders="orders" />
  </section>
</template>
