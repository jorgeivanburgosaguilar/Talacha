import React, { Component } from "react";

function FormattedDate(props) {
    return <h2>It is {props.date.toLocaleTimeString()}.</h2>;
}

// impure?
function AddHours(clockDate, timezoneDiff = 0) {
    clockDate.setHours(clockDate.getHours() + timezoneDiff);
}

export class Clock extends Component {
    constructor(props) {
        super(props);
        let clockDate = new Date();
        AddHours(clockDate, this.props.timezone);
        this.state = { date: clockDate };
    }

    componentDidMount() {
        this.timerID = setInterval(() => this.tick(), 1000);
    }

    componentWillUnmount() {
        clearInterval(this.timerID);
    }

    tick() {
        let clockDate = new Date();
        AddHours(clockDate, this.props.timezone);
        this.setState({
            date: clockDate,
        });
    }

    render() {
        return (
            <div>
                <h1>Clock +{this.props.timezone}</h1>
                <FormattedDate date={this.state.date} />
            </div>
        );
    }
}

export default Clock;
