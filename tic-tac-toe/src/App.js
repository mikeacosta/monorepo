import React from 'react';
import { useState } from 'react';

const Board = ()=> {
  return (
    <React.Fragment>
      <div className="board-row">
        <Square />
        <Square />
        <Square />
      </div>
      <div className="board-row">
        <Square />
        <Square />
        <Square />
      </div>
      <div className="board-row">
        <Square />
        <Square />
        <Square />
      </div>
    </React.Fragment>
  );
}

const Square = () => {
  const [value, setValue] = useState(null);

  function handleClick() {
    setValue('X');
  }

  return (
    <button 
      className="square"
      onClick={handleClick}>{value}</button>
  );
}

export default Board;