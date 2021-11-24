import axios from 'axios'

let api = axios.create({
    baseURL: 'https://localhost:44328/api/v1/',
    headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Credentials': true
    }
})

export default api;