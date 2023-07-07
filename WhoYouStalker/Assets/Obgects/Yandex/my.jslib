mergeInto(LibraryManager.library, {

LiderbordRating: function (titel) {

  ysdk.getPlayer().then( playerLiderBord => {
    if (playerLiderBord.getMode() === 'lite') {
          myGameInstance.SendMessage('YandexSDK', 'PlayGame');
          myGameInstance.SendMessage('Plaer', 'IfPlaerNorReag');
        }
        else
        {
          ysdk.getLeaderboards()
          .then(lb => {
            lb.setLeaderboardScore('topMasterLiderbord', titel);
            });
            myGameInstance.SendMessage('YandexSDK', 'PlayGame');
        }
  });
  },
  ShowRating: function () {
    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },
  ShowNotClipReclama: function () {
    ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          myGameInstance.SendMessage('YandexSDK', 'PausGame');
        },
        onRewarded: () => {
          console.log('Rewarded!');
        },
        onClose: () => {
          myGameInstance.SendMessage('YandexSDK', 'PlayGame');
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
    
  },
  ShowFullScrinReclama: function () {
   ysdk.adv.showFullscreenAdv({
    callbacks: {
       onOpen: () => {
          myGameInstance.SendMessage('YandexSDK', 'PausGame');
        },
        onClose: () => {
          myGameInstance.SendMessage('YandexSDK', 'PlayGame');
        },
    }
})
    
  },
});