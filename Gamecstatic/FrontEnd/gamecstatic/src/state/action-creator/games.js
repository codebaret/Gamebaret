import GameService from "../../services/gameService";
import { FETCH_GAMES, UPLOAD_GAME,FETCH_TAGS,FETCH_CATEGORIES,FETCH_GAME_DETAILS, COMMENT, RATE } from '../type/index'

export const fetchGames = (params) => dispatch => {
    return GameService.fetchGames(params)
        .then(data => {
            dispatch({ type: FETCH_GAMES, payload: data })
            return data
        })
        .catch(err => {
            throw err
        })
}

export const fetchTags = () => dispatch => {
    return GameService.fetchTags()
        .then(data => {
            dispatch({ type: FETCH_TAGS, payload: data })
            return data
        })
        .catch(err => {
            throw err
        })
}

export const fetchGameDetails = (id) => dispatch => {
    return GameService.fetchGameDetails(id)
        .then(data => {
            dispatch({ type: FETCH_GAME_DETAILS, payload: data })
            return data
        })
        .catch(err => {
            throw err
        })
}

export const fetchCategories = () => dispatch => {
    return GameService.fetchCategories()
        .then(data => {
            dispatch({ type: FETCH_CATEGORIES, payload: data })
            return data
        })
        .catch(err => {
            throw err
        })
}

export const uploadGame = (data) => dispatch => {
    return GameService.uploadGame(data)
        .then(data => {
            dispatch({ type: UPLOAD_GAME, payload: data })
            return data
        })
        .catch(err => {
            throw err
        })
}

export const comment = (data) => dispatch => {
    return GameService.comment(data)
        .then(data => {
            dispatch({ type: COMMENT, payload: data })
            return data
        })
        .catch(err => {
            throw err
        })
}

export const rate = (data) => dispatch => {
    return GameService.rate(data)
        .then(data => {
            dispatch({ type: RATE, payload: data })
            return data
        })
        .catch(err => {
            throw err
        })
}