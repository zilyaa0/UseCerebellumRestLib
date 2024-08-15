using System;
using System.Collections.Generic;
using System.Text;

namespace CerebellumRestLib.Helpers
{
    public class CapabilityRights
    {
        private readonly Dictionary<string, bool> _capabilities;

        public CapabilityRights(Dictionary<string, bool> capabilities)
        {
            _capabilities = capabilities;
        }

        public bool CanAssignUser => _capabilities["assign_user"];
        public bool CanAssignStage => _capabilities["assign_status"] && _capabilities["update"]; //assign_state
        public bool CanChangeStadium => _capabilities["confirm"];
        public bool CanAssignOrganisation => _capabilities["assign_department"];
        public bool CanEdit => _capabilities["edit"];
        public bool CanUpdate => _capabilities["update"];
        public bool CanAttachPhotoVideoFromGallery => _capabilities["attach_photo_video_from_gallery"];
        public bool ShowOwner => _capabilities["show_owner"];
        public bool CanEditFiles => _capabilities["edit_files"];
        public bool CanUpdateCustomFields => CanEdit || _capabilities["update_custom_fields"];
        public bool CanUpdateTitle => CanEdit || _capabilities["update_title"];
        public bool CanUpdateText => CanEdit || _capabilities["update_text"];
        public bool CanUpdateWorkType => CanEdit || _capabilities["update_type"];
        public bool CanUpdatePriority => CanEdit || _capabilities["update_priority"];
        public bool CanUpdatePoint => CanEdit || _capabilities["update_point"];
        public bool CanUpdateParentTask => _capabilities["update_parent_task"];
        public bool CanDelete => _capabilities["delete"];
        public bool CanUpdateDeadline => CanEdit || _capabilities["update_deadline"];
    }
}
