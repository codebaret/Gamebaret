import API from './api'

const GameService = {

    fetchGames: (sortState) => {
        return API.post('/games/sortable/',sortState)
            .then(({ data }) => {
                return data
            })
            .catch(err => {
                throw err
            })
    },
    uploadGame: (data) => {
        return API.post('/games/',data)
            .then(({ data }) => {
                return data
            })
            .catch(err => {
                console.log(err);
                throw err
            })
    },
    fetchGameDetails: (id) => {
        return API.get('/games/details/' + id)
            .then(({ data }) => {
                return data
            })
            .catch(err => {
                console.log(err);
                throw err
            })
    },
    fetchTags: () => {
        return API.get('/games/tags/')
            .then(({ data }) => {
                return data
            })
            .catch(err => {
                throw err
            })
    },
    fetchCategories: () => {
        return API.get('/games/categories/')
            .then(({ data }) => {
                return data
            })
            .catch(err => {
                throw err
            })
    },
    comment: (data) => {
        return API.post('/games/comment',data)
            .then(({ data }) => {
                return data
            })
            .catch(err => {
                console.log(err);
                throw err
            })
    },
    rate: (data) => {
        console.log(data);
        return API.post('/games/rate',data)
            .then(({ data }) => {
                return data
            })
            .catch(err => {
                console.log(err);
                throw err
            })
    },
}

export default GameService;