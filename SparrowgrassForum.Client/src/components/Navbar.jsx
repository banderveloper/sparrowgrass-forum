import React from 'react';

const Navbar = () => {
    return (
        <nav className="navbar">
            <ul className="navbar__list">
                <li><a href="/">Form</a></li>
                <li><a href="/records">Records</a></li>
            </ul>
        </nav>
    );
};

export default Navbar;