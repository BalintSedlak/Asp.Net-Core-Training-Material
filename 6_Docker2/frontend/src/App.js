import logo from './logo.svg';
import React, { useState, useEffect  } from 'react';
import './App.css';

function App() {
  const [formData, setFormData] = useState({
    id: '',
    count: '',
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    
    const apiUrl = `${process.env.REACT_APP_PUBLISHER_URL}/products/order`;
    console.log('API URL:', apiUrl);

    try {
      const response = await fetch(process.env.REACT_APP_PUBLISHER_URL + '/products/order', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(formData),
      });

      if (response.ok) {
        alert('Order placed successfully');
      } else {
        alert('Failed to place order');
      }
    } catch (error) {
      console.error('Error:', error);
    }
  };

  return (
    <div className="App">
      <h1>Product Order Form</h1>
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="id">Product ID:</label>
          <input
            type="text"
            id="id"
            name="id"
            value={formData.id}
            onChange={handleChange}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="count">Quantity:</label>
          <input
            type="text"
            id="count"
            name="count"
            value={formData.count}
            onChange={handleChange}
            required
          />
        </div>
        <button type="submit">Place Order</button>
      </form>
    </div>
  );
}

export default App;
