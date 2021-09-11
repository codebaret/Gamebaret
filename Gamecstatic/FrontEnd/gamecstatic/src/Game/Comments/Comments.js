import Comment from "./Comment";
import {useEffect, useState} from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { comment as commentAction } from "../../state/action-creator/games";
import './Comments.scss'

function Comments(props){
    const dispatch = useDispatch()
    const user = useSelector(state => state.authReducer.user)
    const game = props.game;
    const [comment, setComment] = useState("")
    const listedComments = game.comments.map((comment,index) =>
        <Comment key={index} user={game.commentUserNames[index]} date={game.commentDates[index]} content={comment} />
    );
    const userIsLoggedIn = Object.keys(user).length !== 0;
    const onComment = e => {
        if(comment.length < 1) return;
        let data = {UserId:user.id,Comment:comment,GameId:game.id};
        dispatch(commentAction(data))
        .then(data => props.update())
        .catch(err => console.log(err))
        setComment("")
    }
    return (
        <div id="comments" className="w-100">
            {listedComments}
            {userIsLoggedIn ? 
                <div className="d-flex flex-column">
                    <textarea value={comment} onChange={(e)=>setComment(e.target.value)} placeholder="Leave a comment" className="w-100"></textarea>
                    <button onClick={onComment}>Comment</button>
                </div>
                : ""
            }
            
        </div>
        
    );
};

export default Comments;
