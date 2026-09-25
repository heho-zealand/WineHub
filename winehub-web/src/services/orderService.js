const API_URL = 'https://localhost:7049/api'

export async function getOrders() {
  const response = await fetch(`${API_URL}/orders`)

  if (!response.ok) {
    throw new Error(`API returned ${response.status}`)
  }

  return await response.json()
}
