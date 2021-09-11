import { fetchGameDetails } from "../state/action-creator/games";
import { useDispatch } from 'react-redux';
import {useEffect, useState} from 'react';
import './Game.scss'
import Spinner from "../UploadGame/Spinner";
import GameDetails from "./GameDetails/GameDetails";
import GameInfoHeader from "../CommonElements/GameInfoHeader/GameInfoHeader";
import Comments from "./Comments/Comments";

const marginY = 20;

function Game(props){
    useEffect(() => {
        function keyDown(e) {
            if (
                "TEXTAREA" !== e.srcElement.tagName && "INPUT" !== e.srcElement.tagName && 
                (
                    e.key === 'ArrowDown' || e.key === 'ArrowUp' || e.key === 'ArrowLeft' ||
                    e.key === 'ArrowRight' || e.key === ' '
                )
                ) 
           {
               e.preventDefault();
           }
        }
    
        document.addEventListener('keydown', keyDown);
    
        return () => {
          document.removeEventListener('keydown', keyDown);
        };
      }, []);
    
    const gameHasUpdate = () =>{
        dispatch(fetchGameDetails(id)).then(res => setgameDetails(res)).catch(err => console.log(err))
    }
    const dispatch = useDispatch()
    const id = props.match.params.id;
    const [adjustedIframe, setAdjustedFrame] = useState({adjusted:false,scaleDown:0})
    const [gameDetails, setgameDetails] = useState(null)
    const gameUrl = process.env.REACT_APP_URL+"games/" + id + "/";
    useEffect(() => {
        dispatch(fetchGameDetails(id)).then(res => setgameDetails(res)).catch(err => console.log(err))
    }, [dispatch])
    const onLoad = e => {
        if(adjustedIframe.adjusted) return;
        let wantedHeight = window.innerHeight - 2 * marginY;
        let scaleDown = Math.min(wantedHeight / e.target.clientHeight,1);
        e.target.style.transform = "scale("+ scaleDown + ")";
        let marginTop = ( e.target.clientHeight * (1 - scaleDown) ) / -2;
        e.target.style.marginTop  = marginTop+"px";
        e.target.style.marginBottom  = marginTop+"px";
        setAdjustedFrame({adjusted:true,scaleDown:scaleDown});
    }
    if(gameDetails===null) return <Spinner />
    const frameDimensions = {
        height: gameDetails.height + 'px',
        width: gameDetails.width + 'px',
      };
    const containerWidth = {
        width: gameDetails.width * adjustedIframe.scaleDown + 'px',
    };
    return (
        <div id="game-container">
            <div style={containerWidth} className="container">
                <div id="game-info-header"><GameInfoHeader game={gameDetails} /></div>
                <iframe style={frameDimensions} onLoad={onLoad} src={gameUrl} ></iframe>
                <div id="game-info">
                    <GameDetails update={gameHasUpdate} details={gameDetails} />
                </div>
                <Comments update={gameHasUpdate} game={gameDetails} />
            </div>
        </div>
        
    );
};

export default Game;
