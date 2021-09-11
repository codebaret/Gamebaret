import { useDispatch,useSelector } from 'react-redux';
import {useEffect, useState} from 'react';
import { rate } from '../../state/action-creator/games';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faStar } from '@fortawesome/free-solid-svg-icons'
import './GameDetails.scss'


function GameDetails(props){
    const dispatch = useDispatch()
    const user = useSelector(state => state.authReducer.user)
    const game = props.details;
    const creator = <span className="special-text"> {game.userName}</span>;
    const createdDate = <span className="special-text"> {new Date(game.date).toLocaleDateString()}</span>;
    const [starred, setStarred] = useState(game.starred)
    const onRate = e => {
        let data = {UserId:user.id,GameId:game.id};
        dispatch(rate(data))
        .then(data => props.update())
        .catch(err => console.log(err))
        setStarred(!starred);
    }
    const userIsLoggedIn = Object.keys(user).length !== 0;
    return (
        <div id="game-details-container">
            <div className="d-flex align-items-center">
                <p id="main-info">{"Created by "}{creator}{" on "}{createdDate}</p>
                {userIsLoggedIn ? 
                    <p className="d-flex align-items-center">
                        <FontAwesomeIcon onClick={onRate} className={game.starred ? "" : "non-starred"} icon={faStar} />
                    </p>
                    : ""
                }
            </div>
            <p>{game.description}</p>
        </div>
        
    );
};

export default GameDetails;
