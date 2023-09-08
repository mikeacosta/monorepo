function SpeakerFavorite({ favorite, onFavoriteToggle }) {

  function doneCallback() {
    console.log(
      `In SpeakerFavorite:doneCallback    ${new Date().getMilliseconds()}`
    );
  }

  return (
    <div className="action padB1">
      <span
        onClick={function () {
          return onFavoriteToggle(doneCallback);
        }}
      >
        <i className={
            favorite === true ? "fa fa-star orange" : "fa fa-star-o orange"
          }
        />{" "}
        Favorite{" "}
      </span>
    </div>
  );
}

export default SpeakerFavorite;