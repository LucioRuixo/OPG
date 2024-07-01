using UnityEngine;
using TMPro;

namespace OPG.UI
{
    using ProgressionProfiles;

    public class EpisodeLogger : MonoBehaviour
    {
        #region
        private const string CurrentEpisodeText = "Current episode: ";
        #endregion

        [SerializeField] private TMP_Text currentEpisodeText;
        [SerializeField] private TMP_InputField inputField;

        private ProgressionProfile progressionProfile;

        public int Input { get; private set; }

        private void Awake()
        {
            inputField.onValueChanged.AddListener(ProcessInput);

            inputField.onDeselect.AddListener(FormatInput);
            inputField.onSubmit.AddListener(FormatInput);
        }

        public void Initialize(ProgressionProfile progressionProfile)
        {
            this.progressionProfile = progressionProfile;
            UpdateCurrentEpisode(progressionProfile.LoggedEpisodes);

            this.progressionProfile.OnEpisodesLoggedEvent += UpdateCurrentEpisode;

            this.progressionProfile.LogEpisodes(-999); // Debug
        }

        private void ProcessInput(string input)
        {
            if (string.IsNullOrEmpty(input)) Input = 0;
            else if (int.TryParse(input, out int parsedInput)) Input = parsedInput;
        }

        private void FormatInput(string input)
        {
            ProcessInput(input);
            inputField.text = Input == 0 ? string.Empty : Input.ToString();
        }

        #region Handlers
        private void UpdateCurrentEpisode(int loggedEpisodes)
        {
            currentEpisodeText.text = $"{CurrentEpisodeText}{loggedEpisodes}";
            inputField.text = string.Empty;
        }
        #endregion
    }
}