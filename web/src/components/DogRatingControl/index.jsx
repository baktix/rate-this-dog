import { ControlHeader } from './ControlHeader';
import { StarControl } from './StarControl';

import { GET_RANDOM_USER_RATING_API, POST_USER_RATING_API } from '/src/constants';

import { useState, useEffect } from 'react';

function fetchRandomDogRating(setDogId, setImageUrl, setAverageRating, setUserRating) {
  console.log("fetchRandomDogRating(...)");
  fetch(GET_RANDOM_USER_RATING_API)
    .catch(reason => alert(reason)) //TODO: nicer client-side failures
    .then(data => data.json())
    .catch(reason => alert(reason))
    .then(dogRating => {
      console.log(dogRating);
      setDogId(dogRating.dogID);
      setImageUrl(dogRating.imageUrl);
      setAverageRating(dogRating.averageRating);
      setUserRating(0);
    });
}

function submitUserRating(dogId, userRating) {
  console.log(`submitUserRating(${dogId}, ${userRating})`);
  fetch(POST_USER_RATING_API,
    {
      method: "POST",
      headers: new Headers({ 'content-type': 'application/json' }),
      body: JSON.stringify({ dogID: dogId, userRating: userRating })
    }).catch(reason => alert(reason));
}

export function DogRatingControl() {
  const [dogId, setDogId] = useState(0);
  const [userRating, setUserRating] = useState(0);
  const [imageUrl, setImageUrl] = useState("");
  const [averageRating, setAverageRating] = useState(0);

  useEffect(() => {
    fetchRandomDogRating(setDogId, setImageUrl, setAverageRating, setUserRating);
  }, []) // <-- run on first pass only

  return (
    <div className="container">
      <ControlHeader imageUrl={imageUrl} averageRating={averageRating} />
      <div className="row mt-3">
        <div className="col-8 col-xs-12 mb-3">
          <StarControl userRating={userRating} onChange={r => setUserRating(r)} />
        </div>
        <div className="col text-end mb-3">
          <input type="submit"
            className="btn btn-primary h-100"
            onClick={() => {
              userRating && dogId && submitUserRating(dogId, userRating);
              fetchRandomDogRating(setDogId, setImageUrl, setAverageRating, setUserRating);
            }}
            value="Next Doge &raquo;" />
        </div>
      </div>
    </div>
  );
}