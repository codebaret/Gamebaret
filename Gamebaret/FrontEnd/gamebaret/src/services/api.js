import axios from 'axios'
import store from '../state/store'
import { logout } from '../state/action-creator/index'

const API = axios.create({
    baseURL: process.env.REACT_APP_URL,
    headers: {
        'Accept': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token') || ''}`
    }
})

API.interceptors.response.use(
    res => {
        return res
    },
    err => {
        console.log(err.response);
        if (err.response.status !== 401) {
            throw err
        }
        store.dispatch(logout())
    }
)

export default API