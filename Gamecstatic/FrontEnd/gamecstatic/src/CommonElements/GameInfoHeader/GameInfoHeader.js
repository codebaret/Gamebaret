import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faStar } from '@fortawesome/free-solid-svg-icons'

function GameInfoHeader(props){
    const game = props.game;
    const listedTags = game.tags.map((tag,index) =>
        <div className="game-info-list-element light" key={index} >{tag}</div>
    );
    const listedCategories = game.categories.map((category,index) =>
        <div className="game-info-list-element yellow" key={index} >{category}</div>
    );
    return (
        <>
            <div id="game-header" className="d-flex">
                <h6>{game.name}</h6>
                <div className="d-flex align-items-center">
                    <p>{game.starCount}</p>
                    <FontAwesomeIcon icon={faStar} />
                </div>
            </div>
            <div className="d-flex flex-wrap">
                {listedTags}
            </div>
            <div className="d-flex flex-wrap">
                {listedCategories}
            </div>
        </>
        
    );
};

export default GameInfoHeader;
