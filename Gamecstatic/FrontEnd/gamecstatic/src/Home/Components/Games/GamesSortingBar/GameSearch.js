import React, { Component, Fragment } from 'react';

export class GameSearch extends Component {
    constructor(props) {
        super(props);
    }

    onSearch = (evt) => {
        this.props.onSearch(evt.target.value);
    }

    render() {
        return (
          <div id="game-search">
                <input placeholder="Search A Game" onChange={this.onSearch} type="search" aria-label="Search Items"/> 
          </div>
        );
    }
}