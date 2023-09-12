import React, { useState } from "react";


function SpeakerFavorite({ favorite, onFavoriteToggle }) {
  const [inTransition, setInTransition] = useState(false);

  function doneCallback() {
    setInTransition(false);
    console.log(
      `In SpeakerFavorite:doneCallback    ${new Date().getMilliseconds()}`
    );
  }

  return (
    <div className="action padB1">
      <span
        onClick={function () {
          setInTransition(true);
          return onFavoriteToggle(doneCallback);
        }}
      >
        <i className={
            favorite === true ? "fa fa-star orange" : "fa fa-star-o orange"
          }
        />{" "}
        Favorite{" "}
        {inTransition ? (
          <span className="fas fa-circle-notch fa-spin"></span>
        ) : null}        
      </span>
    </div>
  );
}

export default SpeakerFavorite;