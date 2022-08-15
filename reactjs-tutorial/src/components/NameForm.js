import React, { Component } from "react";

export class NameForm extends Component {
    constructor(props) {
        super(props);
        this.state = { inputValue: "", textareaValue: "" };

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleTextAreaChange = this.handleTextAreaChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event) {
        this.setState({ inputValue: event.target.value });
    }

    handleTextAreaChange(event) {
        this.setState({ textareaValue: event.target.value });
    }

    handleSubmit(event) {
        alert("A name was submitted: " + this.state.inputValue + " " + this.state.textareaValue);
        event.preventDefault();
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <label>
                    Name:
                    <input type="text" value={this.state.inputValue} onChange={this.handleInputChange} />
                </label>
                <label>
                    Essay:
                     <textarea value={this.state.textareaValue} onChange={this.handleTextAreaChange} />
                 </label>
                <input type="submit" value="Submit" />
            </form>
        );
    }
}

export default NameForm;
