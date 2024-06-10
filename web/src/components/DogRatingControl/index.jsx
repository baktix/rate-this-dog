import { ControlHeader } from './ControlHeader';
import { StarControl } from './StarControl';
import { useEffect } from 'react';

export function DogRatingControl() {

  useEffect(() => {

  }, []) // <-- empty dependency array === run only once

  return (
    <div className="container">
      <ControlHeader imgSrc="testdog.jpg" />
      <div className="row mt-3">
        <div className="col-8 col-xs-12 mb-3">
          <StarControl />
        </div>
        <div className="col text-end mb-3">
          <input type="submit"
            className="btn btn-primary h-100"
            value="Next Doge &raquo;" />
        </div>
      </div>
    </div>
  );
}