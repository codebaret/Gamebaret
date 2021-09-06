import { combineReducers } from "redux";
import gamesReducer from "./games";
import authReducer from "./auth";

const reducers = combineReducers({
    gamesReducer: gamesReducer,
    authReducer : authReducer,
});

export default reducers;