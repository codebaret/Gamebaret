import React, { useEffect,useState } from 'react'
import { useSelector, useDispatch } from 'react-redux';
import { FileUpload } from './FileUpload/FileUpload';
import { uploadGame,fetchTags,fetchCategories } from "../state/action-creator/games";
import GameMultiSelect from '../Home/Components/Games/GamesSortingBar/GameMultiSelect';
import Spinner from './Spinner';
import './UploadGame.scss'; 

export function UploadGame(){
  const user = useSelector(state => state.authReducer.user)
  const dispatch = useDispatch()
  const [tags, setTags] = useState([])
  const [categories, setCategories] = useState([])
  useEffect(() => {
        dispatch(fetchTags()).then(res => setTags(res.data)).catch(err => console.log(err))
        dispatch(fetchCategories()).then(res => setCategories(res.data)).catch(err => console.log(err))
  }, [dispatch])
  const [uploading, setUploading] = useState(false);
  const [name, setName] = useState("");
  const [height, setHeight] = useState("");
  const [width, setWidth] = useState("");
  const [description, setDescription] = useState("");
  const [file, setFile] = useState(null);
  const [image, setImage] = useState(null);
  const [gameHtml, setGameHtml] = useState(null);
  const [selectedCategories, setSelectedCategories] = useState([])
  const [selectedTags, setSelectedTags] = useState([])
  
  let handleSubmit = e => {
    e.preventDefault();
    let readyForSubmit = file !==null && file.file !==null && image !==null && image.file !==null && gameHtml !== null && gameHtml.file !==null && width!=="" && height!=="" && name!=="" && description !== "" && selectedTags.length > 0;
    if(!readyForSubmit) return;
    setUploading(true);
    let data = {ZippedFile : file.file,Image:image.file,GameHtml:gameHtml.file,Name:name,Description:description,UserId:user.id,TagIds:selectedTags,CategoryIds:selectedCategories};
    
    dispatch(uploadGame(data))
    .then(data => console.log("done"))
    .catch(err => console.log(err))
    .then(data => setUploading(false))
  }
  let readyForSubmit = file !==null && file.file !==null && image !==null && image.file !==null && gameHtml !== null && gameHtml.file !==null && width!=="" && height!=="" && name!=="" && description !== "" && selectedTags.length > 0;
  let buttonDeactive = readyForSubmit ? "" : "deactive";
    return (
      <form id="upload-form" onSubmit={handleSubmit} className="d-flex flex-column align-items-center justify-content-center">
        <h3>Submit an HTML 5 Game</h3>
        <div id="form-container" className="d-flex flex-column w-50">
          <div className="d-flex flex-column">
            <input placeholder="Game Name" id="name" value={name} onChange={(e) => setName(e.target.value)} type="text"></input>
            <textarea placeholder="Game Description" id="description" value={description} onChange={(e) => setDescription(e.target.value)} maxLength="300"/>
            <GameMultiSelect onChange={(v)=>setSelectedCategories(v)} placeholder="Select Categories" values={categories}/>
            <GameMultiSelect onChange={(v)=>setSelectedTags(v)} placeholder="Select Tags" values={tags}/>
            <label>Game Image</label>
            <FileUpload accept="image/*" setFile={(val) => setImage(val)}/>
            {image !== null ? <img src={image.file}/> : ""}
          </div>
          <label>Game Attachment</label>
          <FileUpload accept=".zip" setFile={(val) => setFile(val)}/>
          <label>Game HTML</label>
          <FileUpload accept=".html" setFile={(val) => setGameHtml(val)}/>
          <div className="d-flex justify-content-between">
            <input className="w-40" placeholder="Game Width (px)" value={width} onChange={(e) => setWidth(e.target.value)} type="text"></input>
            <input className="w-40" placeholder="Game Height (px)" value={height} onChange={(e) => setHeight(e.target.value)} type="text"></input>
          </div>
          <input className={buttonDeactive} type="submit" value="Upload Game" />
        </div>
        {uploading ? <Spinner /> : ""}
      </form>
    )
}