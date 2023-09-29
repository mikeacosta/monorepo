import SpeakerDemographics from "./SpeakerDemographics";
import { SpeakerFilterContext } from "../contexts/SpeakerFilterContext";
import { useContext } from "react";

function Session({ title, room }) {
  return (
    <span className="session w-100">
      {title}{" "}
      <strong>Room: {room}</strong>
    </span>
  );
}

function Sessions({ sessions }) {
  return (
    <div className="sessionBox card h-250">
      <Session title={sessions[0].title} room={sessions[0].room.name} />
    </div>
  );
}

function SpeakerImage({ id, first, last }) {
  return (
    <div className="speaker-img d-flex flex-row justify-content-center align-items-center h-300">
      <img
        className="contain-fit"
        src={`/images/speaker-${id}.jpg`}
        width="300"
        alt={`${first} ${last}`}
      />
    </div>
  );
}

function Speaker({ speaker, onFavoriteToggle }) {
  const { id, first, last, sessions } = speaker;
  const { showSessions  } = useContext(SpeakerFilterContext);

  return (
    <div key={id} className="col-xs-12 col-sm-12 col-md-6 col-lg-4 col-sm-12 col-xs-12">
      <div className="card card-height p-4 mt-4">
        <SpeakerImage id={id} first={first} last={last} />
        <SpeakerDemographics {...speaker} onFavoriteToggle={onFavoriteToggle} />
      </div>
      {showSessions === true
        ? <Sessions sessions={sessions} />
        : null}
    </div>
  );
}

export default Speaker;