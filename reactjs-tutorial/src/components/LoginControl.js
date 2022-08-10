import React, { Component } from 'react'
import { ClickButton } from './ClickButton'

export class LoginControl extends Component {
    constructor(props) {
        super(props);
        this.handleLoginClick = this.handleLoginClick.bind(this);
        this.handleLogoutClick = this.handleLogoutClick.bind(this);
        this.state = { isLoggedIn: false };
    }

    handleLoginClick() {
        this.setState({ isLoggedIn: true });
    }

    handleLogoutClick() {
        this.setState({ isLoggedIn: false });
    }

    render() {
        const isLoggedIn = this.state.isLoggedIn;
        let button;

        if (isLoggedIn)
            button = <ClickButton text="Cerrar Sesion" onClick={this.handleLogoutClick} />;
        else
            button = <ClickButton text="Iniciar Sesion" onClick={this.handleLoginClick} />;

        return (
            <div>
                {button}
            </div>
        )
    }
}

export default LoginControl