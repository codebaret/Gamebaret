import React, { Component, Fragment } from 'react';

export class GameSort extends Component {
    constructor(props) {
        super(props);
        this.state = {
            sortBy: "Rating"
        };
    }

    onSort = () => {
        this.props.onSort(this.state.sortBy)
    }

    updateInputValue(evt) {
        this.setState({
          sortBy: evt.target.value
        },()=>this.onSort());
      }

    render() {
        return (
            <div id="game-sort" className="d-flex">
                <select className="w-100" value={this.state.sortBy} onChange={evt => this.updateInputValue(evt)}>
                    <option value="Date-new">Newest Games</option>
                    <option value="Date-old">Oldest Games</option>
                    <option value="Rating">Best Rated Games</option>
                </select>
            </div>
        );
    }
}