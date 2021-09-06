import GameService from "../../services/gameService";
import { FETCH_GAMES, UPLOAD_GAME,FETCH_TAGS,FETCH_CATEGORIES } from '../type/index'

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