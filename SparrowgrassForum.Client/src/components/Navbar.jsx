import React from 'react';
import {BrowserRouter, Link} from "react-router-dom";

const Navbar = () => {
    return (
        <nav className="navbar">
            <ul className="navbar__list">
                <li>
                    <Link to='/'>Form</Link>
                </li>
                <li>
                    <Link to='/records'>Records</Link>
                </li>
            </ul>
        </nav>
    );
};

export default Navbar;