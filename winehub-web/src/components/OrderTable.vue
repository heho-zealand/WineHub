<script setup>
defineProps({
  orders: {
    type: Array,
    required: true
  }
})
</script>

<template>
  <table>
    <thead>
      <tr>
        <th>ID</th>
        <th>Kunde</th>
        <th>Dato</th>
        <th>Total</th>
        <th>Status</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="order in orders" :key="order.id">
        <td>{{ order.id }}</td>
        <td>{{ order.customerName }}</td>
        <td>{{ new Date(order.orderDate).toLocaleDateString('da-DK') }}</td>
        <td>{{ order.total.toLocaleString('da-DK', { style: 'currency', currency: 'DKK' }) }}</td>
        <td>{{ order.status }}</td>
      </tr>
    </tbody>
  </table>
</template>
