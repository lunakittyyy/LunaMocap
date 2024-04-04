import bpy
import csv
from math import radians
from mathutils import Quaternion

csv_file = "C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag\Motion Captures\Capture-4.4.2024.33.12.csv"

left_hand = bpy.data.objects.get("LeftHand")
if left_hand is None:
    bpy.ops.mesh.primitive_cube_add(size=0.1, location=(0, 0, 0))
    left_hand = bpy.context.object
    left_hand.name = "LeftHand"
    left_hand.delta_rotation_quaternion = Quaternion((0.5, 0.5, 0, 0))

right_hand = bpy.data.objects.get("RightHand")
if right_hand is None:
    bpy.ops.mesh.primitive_cube_add(size=0.1, location=(0, 0, 0))
    right_hand = bpy.context.object
    right_hand.name = "RightHand"
    right_hand.delta_rotation_quaternion = Quaternion((0.5, 0.5, 0, 0))

head = bpy.data.objects.get("Head")
if head is None:
    bpy.ops.object.camera_add(location=(0, 0, 0), rotation=(radians(90), 0, 0))
    head = bpy.context.object
    head.name = "Head"
    bpy.context.scene.camera = head
    head.delta_rotation_quaternion = Quaternion((0.5, 0.5, 0, 0))

with open(csv_file, newline='') as csvfile:
    reader = csv.DictReader(csvfile)
    for row in reader:
        frame = int(row['Frame'])

        left_hand.location = (float(row['LHandPosX']), float(row['LHandPosZ']), float(row['LHandPosY']))
        left_hand.rotation_mode = 'QUATERNION'
        left_hand.rotation_quaternion = Quaternion((float(row['LHandRotW']), -float(row['LHandRotX']), -float(row['LHandRotY']), float(row['LHandRotZ'])))
        left_hand.keyframe_insert(data_path="location", index=-1, frame=frame)
        left_hand.keyframe_insert(data_path="rotation_quaternion", index=-1, frame=frame)

        right_hand.location = (float(row['RHandPosX']), float(row['RHandPosZ']), float(row['RHandPosY']))
        right_hand.rotation_mode = 'QUATERNION'
        right_hand.rotation_quaternion = Quaternion((float(row['RHandRotW']), -float(row['RHandRotX']), -float(row['RHandRotY']), float(row['RHandRotZ'])))
        right_hand.keyframe_insert(data_path="location", index=-1, frame=frame)
        right_hand.keyframe_insert(data_path="rotation_quaternion", index=-1, frame=frame)

        head.location = (float(row['HeadPosX']), float(row['HeadPosZ']), float(row['HeadPosY']))
        head.rotation_mode = 'QUATERNION'
        head.rotation_quaternion = Quaternion((float(row['HeadRotW']), -float(row['HeadRotX']), -float(row['HeadRotY']), float(row['HeadRotZ'])))
        head.keyframe_insert(data_path="location", index=-1, frame=frame)
        head.keyframe_insert(data_path="rotation_quaternion", index=-1, frame=frame)
