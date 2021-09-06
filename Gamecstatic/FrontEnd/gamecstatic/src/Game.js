import React, { Component, Fragment } from 'react';
import './Game.scss'

const API_URL = process.env.REACT_APP_URL+"games/";
const marginY = 100;

export default class Game extends Component {
    constructor(props) {
        super(props);
        console.log(props);
        this.state = {
            gameId: props.match.params.id,
            adjustedIframe : false
        };
        this.gameUrl = API_URL + this.state.gameId + "/";
        
    }

    onLoad = e => {
        if(this.state.adjustedIframe) return;
        let wantedHeight = window.innerHeight - 2 * marginY;
        let scaleDown = Math.min(wantedHeight / e.target.clientHeight,1);
        e.target.style.transform = "scale("+ scaleDown + ")";
        let marginTop = ( e.target.clientHeight * (1 - scaleDown) ) / -2;
        e.target.style.marginTop  = marginTop+"px";
        e.target.style.marginBottom  = marginTop+"px";
        this.setState({adjustedIframe:true,menuHeight:wantedHeight});
    }

    render() {
        return (
            <div id="game-container">
                <div className="container">
                    <h4 className>Game Name</h4>
                    <iframe className="responsive-iframe" onLoad={this.onLoad} src={this.gameUrl} ></iframe>
                </div>
                <div id="game-info">
                    WAZZUP
                </div>
            </div>
            
        );
    }
};
