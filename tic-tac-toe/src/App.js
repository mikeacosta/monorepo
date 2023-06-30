import React from 'react';

const Board = ()=> {
  return (
    <React.Fragment>
      <div className="board-row">
        <Square/>
        <Square/>
        <Square/>
      </div>
      <div className="board-row">
        <Square/>
        <Square/>
        <Square/>
      </div>
      <div className="board-row">
        <Square/>
        <Square/>
        <Square/>
      </div>
    </React.Fragment>
  );
}

const Square = ()=> {
  return (
    <button className="square">1</button>
  );
}

export default Board;