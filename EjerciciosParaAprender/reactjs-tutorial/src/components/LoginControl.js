import React, { Component } from "react";
import ClickButton from "./ClickButton";

class LoginControl extends Component {
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
        const clickButtonText = isLoggedIn ? "Cerrar Sesion" : "Iniciar Sesion";
        const clickButtonOnClick = isLoggedIn
            ? this.handleLogoutClick
            : this.handleLoginClick;

        return (
            <div>
                {isLoggedIn ? <h1>Hola de nuevo</h1> : <h1>Bienvenido</h1>}
                <ClickButton
                    text={clickButtonText}
                    onClick={clickButtonOnClick}
                />
            </div>
        );
    }
}

export default LoginControl;
