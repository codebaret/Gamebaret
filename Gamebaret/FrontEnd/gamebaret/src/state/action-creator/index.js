import AuthService from '../../services/authService'
import { LOGIN, REGISTER, LOGOUT } from '../type/index'

export const login = (params, history) => dispatch => {
    return AuthService.login(params)
        .then(data => {
            dispatch({ type: LOGIN, payload: data })
            history.push('/')
        })
        .catch(err => {

        })
}

export const register = (params, history) => dispatch => {
    return AuthService.register(params)
        .then(data => {
            dispatch({ type: REGISTER, payload: data })
            history.push('/')
        })
        .catch(err => {

        })
}

export const logout = () => dispatch => {
    AuthService.logout()
    dispatch({ type: LOGOUT })
}