function Comment(props){
    const user = props.user;
    const content = props.content;
    const date = props.date;
    return (
        <div id="comment" className="d-flex w-100">
            <div id="comment-info" className="d-flex flex-column justify-content-between w-25">
                <p>{user}</p>
                <p>{new Date(date).toLocaleDateString()}</p>
            </div>
            <div className="w-75">
                {content}
            </div>
        </div>
        
    );
};

export default Comment;