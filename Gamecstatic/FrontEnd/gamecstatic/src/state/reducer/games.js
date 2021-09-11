import { FETCH_GAMES, UPLOAD_GAME,FETCH_TAGS,FETCH_CATEGORIES,FETCH_GAME_DETAILS, COMMENT, RATE } from '../type/index'

const initialState = {
    games: [],
    tags: [],
    categories: []
}

const gamesReducer = (state = initialState, action) => {

    const { type, payload } = action

    switch (type) {

        case FETCH_GAMES:
            return {
                ...state,
                games: payload
            }
        case UPLOAD_GAME :
            return {
                state
            }
        case FETCH_TAGS:
            return {
                ...state,
                tags: payload
            }
        case FETCH_CATEGORIES:
            return {
                ...state,
                categories: payload
            }
        case FETCH_GAME_DETAILS:
            return {
                state
            }
        case COMMENT:
            return {
                state
            }
        case RATE:
            return {
                state
            }

        default: {
            return state
        }
    }
}

export default gamesReducer;