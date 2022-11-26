import React from 'react';

const MainForm = () => {

    const handleSubmit = async event => {
        event.preventDefault();
        const form = event.target;

        const response = await fetch('/api', {
            method: "POST",
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                name: form.name.value,
                email: form.email.value
            })
        });

        if (response.ok) {
            document.location.href = '/records';
        }
    }

    return (
        <div className='form-block'>
            <form method='post' action='/api' onSubmit={handleSubmit}>
                <input type="text" name='name'/>
                <input type="email" name='email'/>
                <input type="submit"/>
            </form>
        </div>
    );
};

export default MainForm;