import API from './api'

const AuthService = {
    login: (data) => {
        return API.post('/login/authenticate', data)
            .then(({ data }) => {
                setHeadersAndStorage(data)
                return data
            })
            .catch(err => {
                console.log("Auth service err", err);
                throw err
            })
    },

    register: (data) => {
        return API.post('/login/register', data)
            .then(({ data }) => {
                return data
            })
            .catch(err => {
                console.log("Auth service err", err);
                throw err
            })
    },

    logout: () => {
        API.defaults.headers['Authorization'] = ''
        localStorage.removeItem('user')
        localStorage.removeItem('token')
    },
}

const setHeadersAndStorage = ({ user, token }) => {
    API.defaults.headers['Authorization'] = `Bearer ${token}`
    localStorage.setItem('user', JSON.stringify(user))
    localStorage.setItem('token', token)
}

export default AuthService