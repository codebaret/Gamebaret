import React, { Component, Fragment } from 'react';

export class GameSort extends Component {
    constructor(props) {
        super(props);
        this.state = {
            sortBy: "Name"
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
            <div className="d-flex">
                <Fragment>
                        <h6 className="mb-0 ml-2 mr-1">Sort By</h6>
                        <select value={this.state.sortBy} onChange={evt => this.updateInputValue(evt)}>
                            <option value="Name">Name</option>
                            <option value="Description">Description</option>
                            <option  value="Expiry">Expiry Date</option>
                            <option value="Bid">Last Bid</option>
                        </select>
                </Fragment>
            </div>
        );
    }
}