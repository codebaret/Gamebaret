import React, { Component } from 'react'
import axios from 'axios';
import { FileUpload } from './FileUpload/FileUpload';

const API_URL = process.env.REACT_APP_URL+"game/";

export class UploadGame extends Component{
    constructor(props){
        super(props);
        this.state = {
            uploading: false,
            file: null,
            image: null,
            name : "",
            description: ""
          }
    }
    postSubmission = () => {
      let data = {Data : this.state.file}
      axios.post( `${API_URL}`, data)
    }

    handleSubmit = e => {
      e.preventDefault();
      this.setState({uploading:true});
      const { file,image,name,description } = this.state;
      let data = {GameZip : file.file,ImageFile:image.file,Name:name,Description:description};
      axios.post( `${API_URL}`, data)
      .then(this.setState({uploading:false}))
    }

    stateUpdateFromKey = (key,value) =>{
      switch (key) {
        case "name":
          this.setState({name : value})
          break;
        case "description":
          this.setState({description : value})
          break;
        case "file":
          this.setState({file : value})
          break;
        case "image":
          this.setState({image : value})
          break;
      
        default:
          break;
      }
    }

    handleChange = e => {
      this.stateUpdateFromKey(e.target.id,e.target.value)
    }
  
  render() {
    const { uploading, file,image,name,description } = this.state
    return (
      <form onSubmit={this.handleSubmit} className="d-flex justify-content-center">
        <div className="p-5 d-flex flex-column w-50">
          <h3>Submit an HTML 5 Game</h3>
          <div className="d-flex flex-column">
            <label>Game Name</label>
            <input id="name" value={name} onChange={this.handleChange} type="text"></input>
            <label>Game Description</label>
            <textarea id="description" value={description} onChange={this.handleChange} maxLength="300"/>
            <label>Game Image</label>
            <FileUpload setFile={(val) => this.stateUpdateFromKey("image",val)}/>
            {image !== null ? <img src={image.file}/> : ""}
          </div>
          <label>Game Attachment</label>
          <FileUpload setFile={(val) => this.stateUpdateFromKey("file",val)}/>
          <input type="submit" value="Upload Game" />
        </div>
      </form>
    )
  }
}