//import html from "./EvadetheChaser/EvadetheChaser-master/index.html";
import InnerHTML from 'dangerously-set-html-content'
import axios from 'axios';
import { useEffect,useState } from 'react';
import JSZip from 'jszip';
import FileSaver from 'file-saver';

const API_URL = process.env.REACT_APP_URL+"game/";

const base64ToBuffer = (str) => {
    str = window.atob(str); // creates a ASCII string
    var buffer = new ArrayBuffer(str.length),
        view = new Uint8Array(buffer);
    for(var i = 0; i < str.length; i++){
        view[i] = str.charCodeAt(i);
    }
    return buffer;
}

function Game() {
    const [page, setPage] = useState(1);
    console.log(API_URL)
    useEffect(() => {
        axios.get( `${API_URL}`)
        .then(res=>{
            return base64ToBuffer(res.data.Content);
        })
        .then(res=>{
            var zip = new JSZip();
            zip.loadAsync(res)
            .then(function(zip) {
                console.log(zip)
            });
        })
        .then(res => console.log(res))
        .catch(error => console.log(error));
    }, [page]);
    var file = new File(["Hello, world!"], "hello world.txt", {type: "text/plain;charset=utf-8"});
    FileSaver.saveAs(file);
    
    return (
        //<InnerHTML html={html} />
        //<iframe src=".Game/index.html"></iframe>
        <div></div>
     );
}
  

export default Game; 
